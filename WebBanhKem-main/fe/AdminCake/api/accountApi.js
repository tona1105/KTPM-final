export default{
    login(axios, data){
        return axios.$post('/api/Accounts_Admin/login', data)
    }
}