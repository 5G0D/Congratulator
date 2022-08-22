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

    <q-card-actions align="around">
      <q-btn class="col-12 col-md-5" outline rounded icon="edit" color="white" @click="editOnClick"></q-btn>
      <q-btn class="col-12 col-md-5" outline rounded icon="delete" color="white" @click="deleteOnClick"></q-btn>
    </q-card-actions>
  </q-card>
</template>

<script>
import {api} from "boot/axios";
import {useQuasar} from "quasar";
import {useRouter} from "vue-router/dist/vue-router";

export default {
  name: "HumanElementEditableComponent",
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
    getHuman(){
      this.router.push({name: 'AllBirthdaysView', params: {id: this.id}});
    },

    editOnClick: function (){
      this.router.push({name: 'AllBirthdaysEdit', params: {id: this.id}});
    },

    deleteOnClick: function (){
      this.deleteHuman(this.id);
      this.$emit('deleteHuman', this.id);
      this.router.push({name: 'AllBirthdaysIndex'});
    },

    deleteHuman(id){
      api.post('/api/humans/deleteHuman', null,{ params:{ Id: id } })
        .then((response) => {
          this.q.notify({
            color: 'positive',
            position: 'top',
            message: this.name + ' удалён из списка',
            icon: 'done'
          })
        })
        .catch(() => {
          this.q.notify({
            color: 'negative',
            position: 'top',
            message: 'Не удалось удалить человека из списка',
            icon: 'report_problem'
          })
        });
    },
  }
}
</script>

<style scoped>
.bg-color {
  background-color:rgba(32, 32, 63, 0.2);
}
</style>
