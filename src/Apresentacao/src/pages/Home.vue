<template>
  <q-layout view="lHh Lpr lFf">
    <q-page-container>
      
      <h6>Saldo em conta R$ {{this.ObtemSaldo(data)}}</h6>

      <template>
        <div class="q-pa-md">
          <q-table
            title="Extrato"
            :data="data"
            :columns="columns"
            row-key="name"
          />
        </div>
      </template>

    </q-page-container>
  </q-layout>
</template>

<script>
import { $axios } from 'boot/axios'
import { date } from 'quasar'

export default {
  name: 'MainLayout',
  mounted() {
    this.carregarExtrato();
  },
  data () {
    return {
      data: [],
      leftDrawerOpen: false,
      columns: [
        { name: 'tipo', label: 'Transação', field: 'tipoTransacao', sortable: false, align: 'center', format: (val, row) => this.formataTransacao(val) },
        { name: 'valor', label: 'Valor', field: 'valor', sortable: false, align: 'center', format: (val, row) => this.formataValor(val) },
        { name: 'valor_posterior', label: 'Valor pos Operação', field: 'valorPosterior', sortable: false, align: 'center',  format: (val, row) => this.formataValor(val) },
        { name: 'data_transacao', label: 'Data Transaçao', field: 'dataTrasacao', sortable: false, align: 'center', format: (val, row) => date.formatDate(val, 'DD/MM/YYYY') }
      ]
    }
  },
  methods: {
    formataValor(valor){
      return 'R$ ' + valor;
    },
    formataTransacao(tipo){
      return tipo == 1 ? "Credito" : "Debito"
    },
    ObtemSaldo(extrato){
      return extrato[0].valorPosterior
    },
    carregarExtrato () {
      this.loadingTable = true
      $axios.get('ExtratoContaCorrente')
        .then((response) => {
          this.data = response.data
        })
        .catch((erro) => {
          console.log(erro)
        })
        .finally(() => {
          this.loadingTable = false
        })
    },
  }
}
</script>
