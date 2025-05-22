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
      <button @click="placeOrder" class="btn btn-success">下訂單</button>
      <p v-if="orderMessage && !confirmationRedirected">{{ orderMessage }}</p> <!-- 只有在沒有重定向時顯示消息 -->
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useCartStore } from '../stores/cart';
import { useRouter } from 'vue-router';

const cartStore = useCartStore();
const router = useRouter();

const orderMessage = ref(null);
const confirmationRedirected = ref(false);

const placeOrder = async () => {
  if (cartStore.items.length === 0) {
    orderMessage.value = 'Your cart is empty. Please add items before placing an order.';
    confirmationRedirected.value = false;
    return;
  }

  const orderItems = cartStore.items.map(item => ({
    menuItemId: item.menuItemId,
    quantity: item.quantity
  }));

  const orderRequest = {
    items: orderItems
  };

  try {
    const response = await fetch('/api/orders', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(orderRequest)
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const confirmation = await response.json();

    cartStore.clearCart();

    router.push({
      path: '/order-confirmation',
      query: {
        orderId: confirmation.orderId,
        message: confirmation.message
      }
    });
    confirmationRedirected.value = true;

  } catch (err) {
    orderMessage.value = 'Failed to place order: ' + err.message;
    confirmationRedirected.value = false;
    console.error('Error placing order:', err);
  }
};
</script>
