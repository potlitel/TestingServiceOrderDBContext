//https://dev.to/nadirbasalamah/api-performance-testing-with-k6-a-quick-start-guide-2ngc


import http from 'k6/http';

export const options = {
    vus: 3, // 3 virtual users
    duration: "40s", // duration is 40 seconds
};


export default function () {
    const BASE_URL = 'http://localhost:7002/api';

    // send custom payload/post data
    const payload = JSON.stringify({
        page: 1,
        takeItems: 10,
        totalItems: 0,
        filterTerm: "",
        filter: "",
        orderBy: ""
    });

    // send post request with custom header and payload
    http.post(`${BASE_URL}/so/supplies/include-related-objects/all`, payload, {
        headers: {
            'Content-Type': 'application/json',
        },
    });
}



