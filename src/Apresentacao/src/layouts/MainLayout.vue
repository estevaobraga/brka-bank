<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />

        <q-toolbar-title>
          Berkshire Hathaway Bank
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
      content-class="bg-grey-1"
    >
      <q-list>
        <q-item-label
          header
          class="text-grey-8"
        >
          Brka App
        </q-item-label>
        <EssentialLink
          v-for="link in essentialLinks"
          :key="link.title"
          v-bind="link"
        />
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import EssentialLink from 'components/EssentialLink.vue'

const linksData = [
  {
    title: 'Home / Extrato',
    caption: 'Saldo e Operações',
    icon: 'home',
    link: 'https://quasar.dev'
  },
  {
    title: 'Deposito',
    caption: 'Deposite agora pelo PIX',
    icon: 'attach_money',
    link: 'https://github.com/quasarframework'
  },
  {
    title: 'Resgate',
    caption: 'Resgate agora seus rendimentos',
    icon: 'north',
    link: 'https://chat.quasar.dev'
  },
  {
    title: 'Pagamentos',
    caption: 'Pague seus boletos',
    icon: 'payments',
    link: 'https://forum.quasar.dev'
  }
];

export default {
  name: 'MainLayout',
  components: { EssentialLink },
  data () {
    return {
      leftDrawerOpen: false,
      essentialLinks: linksData
    }
  }
}
</script>
