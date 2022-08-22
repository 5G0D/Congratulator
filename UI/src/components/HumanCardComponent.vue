<template>
  <q-card
    flat
    class="bg-color rounded"
  >
    <q-card-section style="height: 75vh" v-if="humanLoaded">
      <div class="column fit">
        <div class="col q-ma-sm field-bg rounded"><q-img class="rounded" height="100%" fit="cover" :src="human.photo"></q-img></div>
        <div class="col-2 q-ma-sm field-bg rounded text-wrap text-color">
          <div class="q-pa-sm text-center vertical-between">
            <div class="text-weight-bold">Имя</div>
            <div>{{ human.name }}</div>
            <div></div>
          </div>
        </div>
        <div class="col-2 q-ma-sm field-bg rounded text-wrap text-color">
          <div class="q-pa-sm text-center vertical-between">
            <div class="text-weight-bold">Дата рождения</div>
            <div class="">{{ human.birthday }}</div>
            <div></div>
          </div>
        </div>
        <div class="q-pa-sm col-2 q-ma-sm field-bg rounded text-wrap text-color">
          <div class="text-center vertical-between">
            <div class="text-weight-bold">День рождения</div>
            <div class="">{{ human.nextBirthday }}</div>
            <div></div>
          </div>
        </div>
      </div>
    </q-card-section>
  </q-card>
</template>

<style>

</style>

<script>
import {api} from "boot/axios";
import {useQuasar} from "quasar";
import {ref} from "vue";

export default {
  name: "HumanElementCard",

  props: {
    id: String,
  },

  created() {
    this.$watch(
      () => this.$route.params,
      (toParams, previousParams) => {
        this.loadData(toParams.id);
      }
    )
  },

  setup(props, context) {
    const q = useQuasar();

    const human = ref();
    const humanLoaded = ref();

    function loadData(id){
      if (typeof id === 'undefined'){
        humanLoaded.value = false;
        return;
      }

      api.get('/api/humans/getHumanById', { params:{ Id: parseInt(id) } })
        .then((response) => {
          human.value = response.data;
          humanLoaded.value = (response.data === '') ? false : true;
        })
        .catch((e) => {
          q.notify({
            color: 'negative',
            position: 'top',
            message: 'Не удалось получить данные',
            icon: 'report_problem'
          })
        });
    }

    loadData(props.id);

    return { q, human, humanLoaded, loadData}
  }
}
</script>
