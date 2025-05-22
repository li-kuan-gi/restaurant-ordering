<script setup>
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <header>
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/menu">Menu</RouterLink>
      </nav>
    </div>
  </header>

  <RouterView />
</template>
