<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header>
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Menu</RouterLink>
        <RouterLink to="/cart">Cart</RouterLink>
      </nav>
    </div>
  </header>

  <RouterView />
</template>
