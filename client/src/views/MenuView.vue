<template>
  <div>
    <h1>Menu</h1>
    <p v-if="loading">Loading menu...</p>
    <p v-if="error">{{ error }}</p>
    <ul v-if="menuItems.length">
      <li v-for="item in menuItems" :key="item.id">
        {{ item.name }} - ${{ item.price }}
        <button @click="addToCart(item)" class="btn btn-primary btn-sm">加入購物車</button>
      </li>
    </ul>
    <p v-if="!loading && !error && !menuItems.length">No menu items found.</p>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useCartStore } from '../stores/cart'; // 引入購物車 Store

const menuItems = ref([]);
const loading = ref(true);
const error = ref(null);

const cartStore = useCartStore(); // 獲取購物車 Store 實例

// 使用 fetch API 獲取菜單數據
const fetchMenu = async () => {
  try {
    const response = await fetch('/api/menu'); // 使用相對路徑，會通過 Vite 代理轉發到後端
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }
    const data = await response.json();
    menuItems.value = data;
  } catch (err) {
    error.value = 'Failed to fetch menu: ' + err.message;
    console.error('Error fetching menu:', err);
  } finally {
    loading.value = false;
  }
};

// 將品項添加到購物車
const addToCart = (menuItem) => {
  cartStore.addItem(menuItem); // 調用購物車 Store 的 addItem action
  console.log('Added to cart:', menuItem.name);
};

onMounted(() => {
  fetchMenu();
});
</script>
