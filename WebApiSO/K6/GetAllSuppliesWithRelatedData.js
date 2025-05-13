import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
  //stages: [
  //      { duration: '5s', target: 5 },    // Stage 1 (5 seconds): Ramp - up to 5 virtual users over 5 seconds.
  //      { duration: '30s', target: 5 },   // Stage 2 (30 seconds): Stay at 5 virtual users for 30 seconds.
  //      { duration: '5s', target: 50 },   // Stage 3 (5 seconds): Ramp-up to 50 virtual users over 5 seconds.
  //      { duration: '30s', target: 50 },  // Stage 4 (30 seconds): Stay at 50 virtual users for 30 seconds.
  //      { duration: '5s', target: 100 },  // Stage 5 (5 seconds): Ramp-up to 100 virtual users over 5 seconds.
  //      { duration: '30s', target: 100 }, // Stage 6 (30 seconds): Stay at 100 virtual users for 30 seconds.
  //      { duration: '5s', target: 300 },  // Stage 7 (5 seconds): Ramp-up to 300 virtual users over 5 seconds.
  //      { duration: '30s', target: 300 }, // Stage 8 (30 seconds): Stay at 300 virtual users for 30 seconds.
  //      { duration: '5s', target: 0 },    // Stage 9 (5 seconds): Ramp-down to 0 virtual users over 5 seconds.
    //],
    stages: [
        { duration: "1m", target: 100 }, // traffic ramp-up from 1 to 100 users over 5 minutes.
        { duration: "3m", target: 100 }, // stay at 100 users for 30 minutes
        { duration: "3m", target: 0 }, // ramp-down to 0 users
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

//export default function () {
//    const BASE_URL = 'http://localhosst:7002/api';
//    const responses = http.batch([
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//        ['POST', `${BASE_URL}/so/supplies/include-related-objects/all`, null, { tags: { name: 'GeoJsonTile', ctype: 'json' } }],
//  ]);

//  sleep(1); // Wait for 0.1 second between each request (adjust as needed for higher stress)
//}



