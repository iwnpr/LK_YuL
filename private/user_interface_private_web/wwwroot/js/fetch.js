async function PostBytesAsync(url, data) {
    try {
        let _answer =
            await fetch(url, {
                method: "POST",
                credentials: "omit",
                body: data,
                headers: {
                }
            })
                .then((response) => {
                    return response.arrayBuffer().then(data => new Uint8Array(data))
                });

        return _answer;
    }
    catch (error) {
        console.log(error.Message);
        return new Uint8Array();
    }
}

async function GetBytesAsync(url) {
    try {
        let _answer =
            await fetch(url, {
                method: "GET",
                credentials: "omit"
            })
                .then((response) => {
                    return response.arrayBuffer().then(data => new Uint8Array(data))
                });

        return _answer;
    }
    catch (error) {
        console.log(error.Message);
        return new Uint8Array();
    }
}

async function PostFileUploadAsync(url) {
    const input = document.getElementById('uploadFile');

    try {
        let _answer =
            await fetch(url, {
                method: "POST",
                body: input.files[0],
                headers: {
                    "Content-Type": "text/xml",
                    "charset": "utf-8"
                }})
                .then(async (response) => {
                    const data = await response.text();
                    return {
                        Code: response.status,
                        Message: data || response.statusText
                    }
                })

        return _answer;
    }
    catch (error) {
        return ({ Code: 0, Message: error.message });
    }
}