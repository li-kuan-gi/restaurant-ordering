import { createRouter, createWebHistory } from 'vue-router'
import MenuView from '@/views/MenuView.vue'
import CartView from '@/views/CartView.vue'
import OrderConfirmationView from '@/views/OrderConfirmationView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'menu',
      component: MenuView,
    },
    {
      path: '/cart',
      name: 'cart',
      component: CartView,
    },
    {
      path: '/order-confirmation',
      name: 'order-confirmation',
      component: OrderConfirmationView,
    },
  ],
})

export default router
