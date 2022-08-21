<template>
  <q-card
    flat
    class="bg-color rounded"
  >
    <q-card-section>
      <q-scroll-area style="height: 70vh">
        <div class="fit row justify-center items-start content-center items-stretch ">
          <HumanElementCard class="col-12 col-md-3 q-mx-md q-mb-md"
                            v-for="(human, idx) in humans"
                            :key="idx"
                            :name="human.name"
                            :birthday="human.birthday"
                            :photo="human.photo"
                            @click="getHuman(human.id)">
          </HumanElementCard>
        </div>
      </q-scroll-area>
    </q-card-section>
  </q-card>
</template>

<script>
import HumanElementCard from 'components/HumanElementCard.vue'
import {api} from "boot/axios";
import {useQuasar} from "quasar";
import {ref} from 'vue'

export default {
  name: "ComingBirthdaysComponent",
  components: {HumanElementCard},
  setup(){
    const $q = useQuasar();
    const humans = ref(null);

    function loadData () {
      api.get('/api/humans/getHumans')
        .then((response) => {
          humans.value = response.data['humans']
        })
        .catch(() => {
          console.log('error')
          $q.notify({
            color: 'negative',
            position: 'top',
            message: 'Не удалось получить данные',
            icon: 'report_problem'
          })
        });
    }
    loadData();

    return {humans};
  },

  methods: {
    getHuman(id){
      this.$emit('getHuman', id);
    }
  }
}
</script>

<style scoped>

</style>
