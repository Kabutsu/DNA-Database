const createFetchOptions = (method, body = undefined) => {
    const options = { method };
    if (body) {
        options.headers['Content-type'] = 'application/json';
        options.body = JSON.stringify(body);
    }
    return options;
}

const Fetcher = {
    get: async (url) => {
        const response = await fetch(
            url,
            createFetchOptions('GET')
        );
        return response;
    },

    post: async (url, body) => {
        const response = await fetch(
            url, createFetchOptions('POST', body)
        );
        return response;
    }
};

export default Fetcher;
