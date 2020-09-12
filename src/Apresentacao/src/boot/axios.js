import axios from 'axios'

const $axios = axios.create({
  baseURL: `${process.env.API}`,
  headers: { 'Content-Type': 'application/json', 'Cache-Control': 'no-cache', 'Pragma': 'no-cache' }
})

export default ({ Vue }) => {
  Vue.prototype.$axios = $axios
}
export {
  $axios
}