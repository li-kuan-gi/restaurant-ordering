import { createApp } from 'vue'
import { createPinia } from 'pinia'

import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.css'

import App from './App.vue'
import router from './router'

const app = createApp(App)

app.use(router)
app.use(createPinia())

app.mount('#app')
