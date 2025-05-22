<template>
  <div>
    <h1>Menu</h1>
    <p v-if="loading">Loading menu...</p>
    <p v-if="error">{{ error }}</p>
    <ul v-if="menuItems.length">
      <li v-for="item in menuItems" :key="item.id">
        {{ item.name }} - ${{ item.price }}
      </li>
    </ul>
    <p v-if="!loading && !error && !menuItems.length">No menu items found.</p>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';

const menuItems = ref([]);
const loading = ref(true);
const error = ref(null);

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

// 在組件掛載後調用 fetchMenu 函數
onMounted(() => {
  fetchMenu();
});
</script>
