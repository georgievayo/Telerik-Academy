let requester = {
    get: (url) => {
        let promise = new Promise((resolve, reject) => {
            $.ajax({
                url,
                method: "GET",           
                success(response) {
                    resolve(response);
                }
            });
        });

        return promise;
    },
    putJSON: (url, body, options = {}) => {
        let promise = new Promise((resolve, reject) => {
            var headers = options.headers || {};
            $.ajax({
                url,
                headers,
                method: "PUT",
                contentType: "application/json",
                data: JSON.stringify(body),
                success: (response) => {
                    resolve(response);
                }
            });
        });
        return promise;
    },
    postJSON: (url, body, options = {}) => {
        let promise = new Promise((resolve, reject) => {
            var headers = options.headers || {};

            $.ajax({
                url,
                headers,
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(body),
                success: (response) => {
                    resolve(response);
                }
            });
        });
        return promise;
    },
    getJSON: (url, options = {}) => {
        let promise = new Promise((resolve, reject) => {
            let headers = options.headers || {};
            $.ajax({
                url,
                method: "GET",
                header: headers,
                contentType: "application/json",
                success: (response) => {
                    resolve(response);
                }
            });
        });
        return promise;
    }
};