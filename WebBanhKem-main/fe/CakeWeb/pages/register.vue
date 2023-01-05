<template>
            <div class="container">
            <div class="login-form" style="max-width:500px;">
                <ValidationObserver  v-slot="{ invalid }">
                <form method="post" @submit.prevent="registers()"  >
                    <h1 style="margin-left:42px">ĐĂNG KÝ</h1>
                    <div class="input-box">
                        <b style="margin-right:66px">Họ tên</b>
                        <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|alpha"  
                        name="Họ tên">
                        <input name="customername" v-model="dataSubmit.customername" type="text"  placeholder="Nhập tên" >
                         <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                       </ValidationProvider>
                    </div>
                    <div class="input-box">
                        <b>Tên đăng nhập</b>
                        <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|alpha-num"  
                        name="Tên đăng nhập">
                        <input name="customerusername" v-model="dataSubmit.customerusername" type="text"  placeholder="Nhập tên đăng nhập" >
                         <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                       </ValidationProvider>
                    </div>
                    <div class="input-box">
                        <b style="margin-right:42px">Mật khẩu</b>
                        <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|min:6"
                        name="Mật khẩu ">   
                        <input   name="customerpassword" v-model="dataSubmit.customerpassword" type="password" placeholder="Nhập mật khẩu">
                        <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                    </ValidationProvider>
                    </div>                  
                     <div class="input-box">
                        <b style="margin-right:72px">Email</b>
                        <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|email"
                        name="Email "    >
                        <input   name="customerEmail" v-model="dataSubmit.customeremail" type="text"   placeholder="Nhập Email">
                         <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                    </ValidationProvider>
                    </div>
                    <div class="input-box">
                        <b style="margin-right:14px">Số điện thoại</b>
                       <ValidationProvider
                        v-slot="{ errors }"
                        rules="required|max:10|min:9|num"
                        name="Số điện thoai "    >
                        <input   name="customernumber" v-model="dataSubmit.customernumber" type="text" placeholder="Nhập số điện thoại">
                        <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                    </ValidationProvider>
                    </div>                  
                    <div class="input-box">
                        <b style="margin-right:64px">Địa chỉ</b>
                       <ValidationProvider
                        v-slot="{ errors }"
                        rules="required"
                        name="Địa chỉ"    >
                        <input   name="customeraddress"  v-model="dataSubmit.customeraddress"  type="text" placeholder="Nhập địa chỉ">
                        <p class="muted text-danger">
                        {{ errors[0] }}
                        </p>
                    </ValidationProvider>
                    </div>                     
                    <div class="btn-box">
                        <button class="btn-submit" :disabled="invalid" type="submit" >
                            Đăng ký
                        </button>
                    </div>
                </form> 
               </ValidationObserver>
            </div>
            </div>
</template>
<script src="https://cdn.jsdelivr.net/npm/vee-validate@<3.0.0/dist/vee-validate.js"></script>
<script>
import Apidata from '@/api/Apidata'
import { Validator } from 'vee-validate';
import { extend } from 'vee-validate';
extend('alpha', {
  validate(value) {
    const nameformat = /^[A-Za-z ]+$/i
    if(!nameformat.test(value)) {
        return 'Chỉ cho phép kí tự chữ cái'
    }
    else return true
  },
});

extend('alpha-num', {
  validate(value) {
    const usernameformat = /^[a-z0-9]+$/i
    if(!usernameformat.test(value)) {
        return 'Chỉ cho phép kí tự chữ cái và số'
    }
    else return true
  },
});


extend('num', {
  validate(value) {
    const phone = /^[0-9]+$/
    if(!phone.test(value)) {
        return 'Chỉ cho phép kí tự số'
    }
    else return true
  },
});
export default {
  layout: 'default',
 data(){
        return{
          dataSubmit:{
                customername: '',
                customerusername: '',
                customerpassword: '',
                customeremail: '',
                customernumber: '',
                customeraddress: '',
          }
        }
    },

    methods:{
      async registers() {
      try {
      await Apidata.register(this.$axios, this.dataSubmit)
      alert("Bạn đã đăng kí thành công.")
       this.$router.push(`/login`)
      } catch (err) {
        alert("Tên đăng nhập hoặc email đã tồn tại")
      }

    }
}
}
</script>
<style scoped>
.main{
    background-color: #dddddd;
    min-height: 500px;
    padding: 7.5px 15px;
}

.containerf{
    height: 1000px;
    margin-top: 50px;
    margin-bottom: 50px;
}
.login-form{
    width: 100%;
    max-width: 400px;
    margin: 80px auto;
    background-color: #e1e8eb;
    padding: 15px;
    border: 2px dotted #cccccc;
    border-radius: 10px;
}
h1{
    color: #009999;
    font-size: 20px;
    margin-bottom: 30px;
    text-align: center;
    font-family: sans-serif;
    font-size: 40px;
}
.input-box{
    display: flex;
}
.input-box input{
    margin-left: 10px;
    padding: 7.5px 15px;
    width: 237px;
    border: 1px solid #cccccc;
    outline: none;
}
.input-box p {
    margin-left: 10px;
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
    border-radius: 2px;
    background-color: #009999;
    color: #ffffff;
    border: none;
    outline: none;
}
</style>