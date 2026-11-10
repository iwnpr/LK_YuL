using application_lib.Entities;
using application_lib.Entities.Records;
using bureau_web_ui_lib;
using legal_persons_lib.Entities;
using legal_persons_lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace application_lib.Services
{
    public interface IUploadManager
    {
        Task<DBUpload?> GetAsync(long _id, long lpId);

        Task<DBUpload?> GetSingleAsync(string _id, long lpId);

        Task<List<Upload>> GetListAsync(long _orgId, int _page, long uploadOrgId, DateOnly date);

        Task<Answer> GetUploadXMLResult(long _id);

        Task<bool> UpdateUploadAsync(DBUpload _upload);
    }

    public class UploadManager : IUploadManager
    {
        private readonly IRepository<DBOrganization> _organizations;
        private readonly IDbContextFactory<BureauWebUIContext> _contextFactory;
        private readonly ILogger<UploadManager> _logger;

        public UploadManager(IRepository<DBOrganization> organizations, IDbContextFactory<BureauWebUIContext> contextFactory, ILogger<UploadManager> logger)
        {
            //_uploads = uploads;
            _organizations = organizations;
            _contextFactory = contextFactory;
            _logger = logger;
        }

        /// </<inheritdoc/>>
        public async Task<DBUpload?> GetAsync(long _id, long lpId)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            return await context.TeRequestsOfUpload.FirstOrDefaultAsync(_item => _item.Id.Equals(_id) && (_item.OrganizationId.Equals(lpId) || lpId.Equals(0)));
        }

        /// </<inheritdoc/>>
        public async Task<DBUpload?> GetSingleAsync(string _id, long lpId)
        {
            await using var context = await _contextFactory.CreateDbContextAsync();

            return await context.TeRequestsOfUpload.FirstOrDefaultAsync(_item => _item.UploadId.Equals(_id) && (_item.OrganizationId.Equals(lpId) || lpId.Equals(0)));
        }

        /// </<inheritdoc/>>
        public async Task<List<Upload>> GetListAsync(long _orgId, int _page, long uploadOrgId, DateOnly date)
        {
            DBOrganization? _org = await _organizations.GetSingleAsync(o => o.LegalPersonId.Equals(_orgId));

            DateTime start = DateTime.Parse(date.ToString());
            DateTime end = start.Equals(DateTime.MinValue) ? DateTime.MaxValue : start.AddDays(1);

            await using var context = await _contextFactory.CreateDbContextAsync();

            List<DBUpload> _uploads =
                _orgId.Equals(0)
                ? uploadOrgId.Equals(-1)
                    ? await context.TeRequestsOfUpload.AsNoTracking().Where(upload => upload.Inserted >= start && upload.Inserted <= end).OrderByDescending(x => x.Inserted).Skip(_page * 20).Take(20).ToListAsync()
                    : await context.TeRequestsOfUpload.AsNoTracking().Where(x => x.OrganizationId.Equals((long)uploadOrgId) && x.Inserted >= start && x.Inserted <= end).OrderByDescending(x => x.Inserted).Skip(_page * 20).Take(20).ToListAsync()
                : await context.TeRequestsOfUpload.AsNoTracking()
                    .Where(upload => upload.OrganizationId.Equals((long)_orgId) && upload.Inserted >= start && upload.Inserted <= end)
                    .OrderByDescending(x => x.Id).Skip(_page * 20).Take(20).ToListAsync();
                  
            List<DBOrganization> _list = await _organizations.GetListAsync();

            return _uploads.Join(_list, u => u.OrganizationId, o => o.LegalPersonId, (u, o) => new Upload(u.Id, u.Inserted, u.UploadXML, u.Status.Equals(4) && XDocument.Parse(u.UploadXML).Descendants("error-count").Any() ? 5 : u.Status.Equals(4) && u.UploadResultXml is null ? -1 :u.Status, o.ShortName/*, u.UserId.ToString()!*/)).ToList();
        }

        /// </<inheritdoc/>>
        public async Task<bool> UpdateUploadAsync(DBUpload _upload)
        {
            try
            {
                await using var context = await _contextFactory.CreateDbContextAsync();

                context.Entry(_upload).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }


        public async Task<Answer> GetUploadXMLResult(long _id)
        {
            try
            {
                await using var context = await _contextFactory.CreateDbContextAsync();
                context.Database.SetCommandTimeout(TimeSpan.FromMinutes(1));

                UploadResult? _result = (await context.UploadResults.FromSqlRaw($"select [dbo].[loader_getUploadResultXmlByKeyId] ({_id}) as xml").ToListAsync())?.FirstOrDefault();

                if (_result?.Xml is not null)
                    return new(200, _result.Xml);
            }
            catch(Exception _ex)
            {
                _logger.LogError($"Ошибка формирования извещения {_ex.Message}");
                return new(-1, "Ошибка формирования извещения");
            }

            return new(200, "<Empty />"); ;
        }
    }
}
