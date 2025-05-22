<template>
  <div>
    <h1>Order Confirmation</h1>
    <div v-if="confirmation">
      <p>Order placed successfully!</p>
      <p>Order ID: {{ confirmation.orderId }}</p>
      <p>Message: {{ confirmation.message }}</p>
    </div>
    <div v-else>
      <p>No order confirmation found.</p>
    </div>
    <router-link to="/">Back to Menu</router-link>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const confirmation = ref(null);

onMounted(() => {
  if (route.query.orderId && route.query.message) {
    confirmation.value = {
      orderId: route.query.orderId,
      message: route.query.message
    };
  }
});
</script>
