<template>
  <q-card
    flat
    class="bg-color rounded"
  >
    <q-card-section>
      <q-scroll-area style="height: 70vh">
        <div class="fit row justify-center items-start content-center items-stretch ">
          <HumanElementEditableComponent @deleteHuman="deleteHuman($event)" class="col-12 col-md-3 q-mx-md q-mb-md"
                            v-for="(human, idx) in humans"
                            :key="idx"
                            :id="human.id"
                            :name="human.name"
                            :nextBirthday="human.nextBirthday"
                            :photo="human.photo">
          </HumanElementEditableComponent>
        </div>
      </q-scroll-area>
    </q-card-section>
  </q-card>
</template>

<script>
import {api} from "boot/axios";
import {useQuasar} from "quasar";
import {ref} from 'vue';
import moment from 'moment';
import HumanElementEditableComponent from "components/HumanElementEditableComponent";
import {useRouter} from "vue-router/dist/vue-router";

export default {
  name: "AllBirthdaysComponent",
  components: {HumanElementEditableComponent},

  setup(props, context){
    const $q = useQuasar();
    const humans = ref(null);
    const router = useRouter();

    function sortHumans(humans){
      return humans.sort((h1, h2) => {
        if (moment(h1.nextBirthday, "DD.MM.YYYY") > moment(h2.nextBirthday, "DD.MM.YYYY"))
          return 1;
        else if (moment(h2.nextBirthday, "DD.MM.YYYY") > moment(h1.nextBirthday, "DD.MM.YYYY"))
          return -1;
        else
          return 0;
      });
    }

    function loadData () {
      api.get('/api/humans/getHumans')
        .then((response) => {
          humans.value = sortHumans(response.data['humans']);
        })
        .catch((e) => {
          console.log(e)
          $q.notify({
            color: 'negative',
            position: 'top',
            message: 'Не удалось получить данные',
            icon: 'report_problem'
          })
        });
    }
    loadData();

    return { humans, router};
  },

  methods: {
    deleteHuman(id){
      this.humans = this.humans.filter(function(h, index, arr) {
        return h.id != id;
      });
    }
  }
}

</script>

<style scoped>

</style>
