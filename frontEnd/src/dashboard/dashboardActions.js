import axios from 'axios'

const BASE_URL = 'http://localhost:56985/api/'

export function getSummary() {
    const request = axios.get(`${BASE_URL}/Summary`)
    return {
        type: 'BILLING_SUMMARY_FATCHED',
        payload: request
    }
}