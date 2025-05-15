//https://dev.to/nadirbasalamah/api-performance-testing-with-k6-a-quick-start-guide-2ngc


import http from 'k6/http';

export const options = {
    stages: [
        { duration: "2m", target: 500 }, // fast ramp-up without any break
        { duration: "1m", target: 0 }, // quick ramp-down
    ],
  thresholds: {
    http_req_failed: ['rate<0.02'], // los errores http deben ser menores al 2%
    http_req_duration: ['p(95)<2000'], // por lo menos el 95% de los request deben durar menos de 2s
  },
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



