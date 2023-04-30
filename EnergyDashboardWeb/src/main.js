import { createApp } from 'vue'

import App from './App.vue'
import {createRouter, createWebHistory, useRouter} from 'vue-router'
import Home from './views/Home.vue'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: Home
        },
        {
            path: '/about',
            component: () => import("./views/About.vue")
        },        
        {
            path: '/buildings',
            component: () => import("./views/Buildings.vue")
        },
        {
            path: '/buildings/:id',
            component: () => import("./views/Building.vue")
        },
        
    ]
})

createApp(App).use(router).mount('#app')
