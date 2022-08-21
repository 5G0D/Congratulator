<template>
  <q-card
    flat
    class="bg-color rounded"
  >
    <q-card-section v-if="humanLoaded">
      <q-scroll-area style="height: 70vh">
        <div class="border">
          <q-img style="max-height: 30vh" fit="contain" class="rounded" :src="human.photo"></q-img>
        </div>
        <div class="text-h6 text-grey-3 q-mt-lg">Имя: {{ human.name }}</div>
        <div class="text-h6 text-grey-3 q-mt-lg">Дата рождения: {{ human.birthday }}</div>
        <div class="text-h6 text-grey-3 q-mt-lg">День рождения: {{ human.nextBirthday }}</div>
      </q-scroll-area>
    </q-card-section>
  </q-card>
</template>

<style>
  .bg-color {
    background-color:rgba(32, 32, 63, 0.5);
  }

  .border{
    border: 1px solid rgba(32, 32, 63, 0.2);
    border-radius: 25px;
  }
</style>

<script>
import {api} from "boot/axios";

export default {
  name: "HumanElementCard",

  data(){
    return{
      humanId: 0,
      human: Object,
      humanLoaded: Boolean,
    }
  },

  mounted(){
    this.humanLoaded = false;
  },

  methods: {
    getHuman(id){
      let obj = {};
      obj.Id = id;

      api.get('/api/humans/getHumanById', { params:{ Id: id } })
        .then((response) => {
          this.human = response.data;
          this.humanLoaded = (response.data === '') ? false : true;
        })
        .catch(() => {
          $q.notify({
            color: 'negative',
            position: 'top',
            message: 'Не удалось получить данные',
            icon: 'report_problem'
          })
        });
    },


  }
}
</script>
