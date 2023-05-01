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
    <div class="login">
        <h1>Login</h1>
        <input placeholder="username" class="form-control w-50" v-model="username" />
        <input placeholder="password" class="form-control w-50" v-model="password" />
        <button class="btn btn-primary" @click="login(username, password)">Submit</button>

    </div>
</template>


<style>
.login{
    width: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

}

.login input{
    text-align: center;
}
</style>