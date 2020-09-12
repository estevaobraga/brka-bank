<template>
  <div class="q-pa-md" style="max-width: 400px">

    <q-form
      class="q-gutter-md"
    >
      <q-input
        filled
        v-model="login"
        label="Login / CPF"
      />

      <q-input
        filled
        v-model="password"
        type="password"
        label="Password"
      />

      <div>
        <q-btn label="Entrar" color="primary" :to="{name: 'home'}" />
      </div>
    </q-form>

  </div>
</template>

<script>
import { openURL } from 'quasar'

export default {
  data () {
    return {
      login: null,
      password: null
    }
  },
  methods: {
    openURL
  }
}
</script>
