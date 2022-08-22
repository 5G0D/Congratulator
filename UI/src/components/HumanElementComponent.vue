<template>
  <q-card
    flat
    class="rounded bg-color"
  >
    <q-card-section style="height: 34vh" @click="getHuman">
      <div class="column fit justify-center">
        <div class="col-6 q-mb-xs field-bg rounded-5"><q-img class="rounded-5" height="100%" fit="cover" :src="photo"></q-img></div>
        <div class="col-3 q-my-xs field-bg rounded-5 text-wrap text-color">
          <div class="q-pa-xs text-center vertical-center"> {{ name }}</div>
        </div>
        <div class="col-2 q-mt-xs field-bg rounded-5 text-wrap text-color">
          <div class="q-pa-xs text-center vertical-center"> {{ nextBirthday }}</div>
        </div>
      </div>
    </q-card-section>
  </q-card>
</template>

<script>
import {useQuasar} from "quasar";
import {useRouter} from "vue-router/dist/vue-router";

export default {
  name: "HumanElementComponent",
  props: {
    id: Number,
    name: String,
    nextBirthday: String,
    photo: String,
  },

  setup(props, context) {
    const q = useQuasar();
    const router = useRouter()

    return { q, router}
  },

  methods: {
    getHuman() {
      this.router.push({name: 'ComingBirthdaysView', params: {id: this.id}});
    },
  }
}
</script>

<style scoped>
  .bg-color {
    background-color:rgba(32, 32, 63, 0.2);
  }
</style>
