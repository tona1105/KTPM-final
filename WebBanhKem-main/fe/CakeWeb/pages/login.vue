<template>
            <div class="containerf">
            <div class="login-form" >
                <ValidationObserver  v-slot="{ invalid }">
                <form @submit.prevent="onSubmit" >
                    <h1>Đăng nhập</h1>
                    <div class="input-box">
                        <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|alpha-num"  
                        name="Tên đăng nhập"
                        >
                        <input type="text" v-model="dataSubmit.username" placeholder="Tên đăng nhập" validateOnInput >
                        <p class="muted text-danger" >
                        {{ errors[0] }}
                        </p>
                       </ValidationProvider>
                    </div>

                    <div class="input-box">

                        <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|alpha-num"  
                        name="Mật khẩu">
                        <input type="password"   v-model="dataSubmit.password" placeholder="Mật khẩu">
                        <p class="muted text-danger" >
                        {{ errors[0] }}
                        </p>
                       </ValidationProvider>
                    </div>                  
                    <div class="btn-box">
                 
                        <button class="btn-submit" :disabled="invalid" type="submit">
                            Đăng nhập
                        </button>
                        <div class="text">
                             <p>Chưa có tài khản ? </p>
                              <p>Đăng ký: <a href="/register" style="color:red; font-size:12px" >Tại đây</a></p>
                        </div>
                    </div>
                </form>
                </ValidationObserver>
            </div>
            </div>

</template>
<script>
import { mapActions } from 'vuex'
import { extend } from 'vee-validate';
import accountApi from '@/api/accountApi'

extend('alpha-num', {
  validate(value) {
    const usernameformat = /^[a-z0-9]+$/i
    if(!usernameformat.test(value)) {
        return 'Chỉ cho phép kí tự chữ cái và số'
    }
    else return true
  },
});
export default {
    middleware: [
    'isLogin',
  ],
  layout: 'default',
 data(){
        return{
            dataSubmit:  {
                customername: '',                 
                customerpassword: '',
            }
        }
    },
    methods:{
        ...mapActions({
      setToken: 'user/setToken',
      setRole: 'user/setRole',
    }),
    async onSubmit() {
      try {
        
        const data = await accountApi.login(this.$axios, this.dataSubmit)
        console.log(data.access_token)
        await this.setToken(data.access_token)
        await this.setRole(data.role)

        this.$router.push('/')
      } catch (err) {
        console.log(err)
        alert('Sai tên đăng nhập hoặc mật khẩu')
      }
    },
    }
}
</script>
<style scoped>
.btn--disable{
    cursor: default;
    pointer-events: none;
    background-color: #ccc !important;
}

main{
    background-color: #dddddd;
    min-height: 300px;
    padding: 7.5px 15px;
}
p{
    text-align: center;
}
.text{
    margin-top: 15px;
    padding: 10px;
}
.containerf{
    
    margin-top: 100px;
    margin-bottom: 100px;
}
.login-form{
    width: 100%;
    max-width: 400px;
    margin: 20px auto;
    background-color: #e1e8eb;
    padding: 15px;
  
    border-radius: 10px;
    height: 450px;
}
h1{
    color: #009999;
    font-size: 20px;
    margin-bottom: 30px;
    text-align: center;
    font-family: sans-serif;
    font-size: 40px;
}
.input-box input{
    padding: 7.5px 15px;
    width: 100%;
    border: 1px solid #cccccc;
    outline: none;
    border-radius: 2px;
}
.btn-box{
    text-align: right;
    margin-top: 30px;
}
.btn-submit:disabled {
    background-color: #cccccc;
}
.btn-box button{
    padding: 7.5px 15px;
    border-radius: 5px;
    background-color: #009999;
    color: #ffffff;
    border: none;
    outline: none;
    
}
button:hover {
  background: rgb(36, 123, 223);
}

i, span {
    display: block;
}
</style>