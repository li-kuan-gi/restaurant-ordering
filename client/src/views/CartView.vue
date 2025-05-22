<template>
  <div>
    <h1>Shopping Cart</h1>
    <p v-if="cartStore.items.length === 0">Your cart is empty.</p>
    <ul v-if="cartStore.items.length > 0">
      <li v-for="item in cartStore.items" :key="item.menuItemId">
        {{ item.name }} - ${{ item.price }} x {{ item.quantity }}
        <button @click="cartStore.removeItem(item.menuItemId)" class="btn btn-danger btn-sm">移除</button>
      </li>
    </ul>
    <div v-if="cartStore.items.length > 0">
      <h3>Total Items: {{ cartStore.totalQuantity }}</h3>
      <h3>Total Price: ${{ cartStore.totalPrice.toFixed(2) }}</h3>
      <button @click="cartStore.clearCart()" class="btn btn-warning">清空購物車</button>
      <!-- TODO: Add checkout button -->
    </div>
  </div>
</template>

<script setup>
import { useCartStore } from '../stores/cart'; // 引入購物車 Store

const cartStore = useCartStore(); // 獲取購物車 Store 實例
</script>
