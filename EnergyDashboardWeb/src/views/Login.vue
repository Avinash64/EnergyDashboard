<script setup>
import { ref } from 'vue';

import { useRouter } from 'vue-router';
const router = useRouter()
const username = ref('')
const password = ref('')

const login = (username, password) => {
    console.log(username, password)
    const options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: `{"username":"${username}","password":"${password}"}`
    };

    fetch('http://localhost:5156/api/login', options)
        .then(response => response.json())
        .then(response => {console.log(response); 
        if(response.token){
            localStorage.setItem('token', response.token)
            router.push('/');
        }
        else {
            alert("login failed")
        }
        })
        .catch(err => console.error(err));
}

</script>
<template>
    <div class="loginPage">

        <div class='login'>
            <h1 class='text-center'>Login</h1>
            <form class='needs-validation'>
                <div class='form-group'>
                    <label class='form-label' for="username">Username</label>
                    <input class='form-control' id="username"  v-model="username"  required>
                    <div class='invalid-feedback'>
                        Please enter a valid
                    </div>
                </div>
                
                <div class='form-group'>
                    <label class='form-label' for="password">Password</label>
                    <input class='form-control' id="password" type="password" v-model="password"  required>
                    <div class='invalid-feedback'>
                        Please enter a valid
                    </div>
                </div>
                
                
                
                <input class='btn btn-success w-100' @click="login(username, password)" value="login">
                
            </form>

        </div>

        </div>
</template>


<style>
.loginPage{
    width: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

}

.login {
    width: 50%;
    max-width: 500px;
    height: min-content;
    padding: 20px;
    border-radius: 12px;
    background: #ffffff;
}

.login h1 {
    font-size: 36px;
    margin-bottom: 25px;
}

.login form{
    font-size: 20px;
}

.login form .form-group {
    margin-bottom: 12px;
}

.login form input[type="submit"] {
    font-size: 20px;
    margin-top: 15px;
}

.login input{
    text-align: center;
}
</style>