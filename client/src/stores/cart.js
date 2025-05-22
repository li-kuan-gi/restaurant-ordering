import { defineStore } from 'pinia';

export const useCartStore = defineStore('cart', {
  state: () => ({
    items: [] // 購物車中的品項列表，每個品項可能包含 MenuItemId 和 Quantity
  }),
  actions: {
    // 添加品項到購物車
    addItem(menuItem) {
      const existingItem = this.items.find(item => item.menuItemId === menuItem.id);

      if (existingItem) {
        existingItem.quantity++;
      } else {
        this.items.push({
          menuItemId: menuItem.id,
          quantity: 1,
          name: menuItem.name, // 可以儲存品項名稱，方便顯示
          price: menuItem.price // 可以儲存品項價格
        });
      }
    },
    // 從購物車移除品項
    removeItem(menuItemId) {
      this.items = this.items.filter(item => item.menuItemId !== menuItemId);
    },
    // 清空購物車
    clearCart() {
      this.items = [];
    }
  },
  getters: {
    // 計算購物車總數量
    totalQuantity: (state) => {
      return state.items.reduce((total, item) => total + item.quantity, 0);
    },
    // 計算購物車總金額
    totalPrice: (state) => {
      return state.items.reduce((total, item) => total + (item.price * item.quantity), 0);
    }
  }
});
