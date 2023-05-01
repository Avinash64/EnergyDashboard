<script setup>
import { ref } from 'vue';
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
        }
        })
        .catch(err => console.error(err));
}

</script>
<template>
    <div>

        <input v-model="username" />
        <input v-model="password" />
        <button @click="login(username, password)">Submit</button>

    </div>
</template>


<style></style>