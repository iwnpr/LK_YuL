using System.Xml.Serialization;

namespace user_interface_private_web.Entities.XML
{
    [XmlType(TypeName = "issues")]
    public class Issues
    {
        [XmlElement("issue")] public List<Issue> IssueList { get; set; } = new();
    }

    public class Issue
    {
        [XmlElement("id")] public string? Id { get; set; }
        
		[XmlElement("project")] public Project? Project { get; set; }
        
		[XmlElement("tracker")] public Tracker? Tracker { get; set; }
        
		[XmlElement("status")] public Status? Status { get; set; }
        
		[XmlElement("author")] public Author? Author { get; set; }
        
		[XmlElement("subject")] public string? Subject { get; set; }
        
		[XmlElement("description")] public string? Description { get; set; }
        
		[XmlElement("start_date")] public DateTime? StartDate { get; set; }
        
		[XmlElement("due_date")] public DateTime? DueDate { get; set; }
        
		[XmlElement("done_ratio")] public string? DoneRatio { get; set; }
        
		[XmlElement("is_private")] public string? IsPrivate { get; set; }

        [XmlElement("created_on")] public DateTime? CreatedOn { get; set; }
        
		[XmlElement("updated_on")] public DateTime? UpdatedOn { get; set; }
        
		[XmlElement("closed_on")] public DateTime? Closed_on { get; set; }


    }

    public class Project
    {
        [XmlAttribute("id")] public string? Id { get; set; }

        [XmlAttribute("name")] public string? Name { get; set; }
    }

    public class Tracker
    {
        [XmlAttribute("id")] public string? Id { get; set; }

        [XmlAttribute("name")] public string? Name { get; set; }
    }


    public class Status
    {
        [XmlAttribute("id")] public string? Id { get; set; }

        [XmlAttribute("name")] public string? Name { get; set; }
    }

    public class Author
    {
        [XmlAttribute("id")] public string? Id { get; set; }

        [XmlAttribute("name")] public string? Name { get; set; }
    }

    /*<issue>
		<id>49621</id>
		<project id="4" name="Сервис ФЛ" />
		<tracker id="4" name="Обращения" />
		<status id="5" name="Открыта" />
		<priority id="2" name="Средний" />
		<author id="16" name="www Bot" />
		<subject>test</subject>
		<description>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the
			industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and
			scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into
			electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of
			Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like
			Aldus PageMaker including versions of Lorem Ipsum.</description>
		<start_date>2024-11-05 15:27:27</start_date>
		<due_date />
		<done_ratio>100</done_ratio>
		<is_private>false</is_private>
		<estimated_hours />
		<custom_fields type="array">
			<custom_field id="1" name="Инициатор">
				<value>8</value>
			</custom_field>
			<custom_field id="4" name="email">
				<value></value>
			</custom_field>
			<custom_field id="3" name="ID физлица в ЛК ФЛ">
				<value></value>
			</custom_field>
			<custom_field id="6" name="ФИО физлица в ЛК ФЛ">
				<value>kolesin</value>
			</custom_field>
			<custom_field id="8" name="Ответ клиенту">
				<value />
			</custom_field>
		</custom_fields>
		<created_on>2024-11-05 15:27:27</created_on>
		<updated_on>2024-11-05 15:27:27</updated_on>
		<closed_on />
	</issue>*/
}
