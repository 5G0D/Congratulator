<template>
  <q-card
    flat
    class="bg-color rounded"
  >
    <q-card-section style="height: 75vh">
      <div class="column fit">
        <div class="col field-bg rounded">
          <q-img class="rounded" height="100%" fit="cover" :src="imageUrl"></q-img>
        </div>
        <div class="col-1 q-my-md no-wrap">
            <q-file
              v-model="image"
              filled
              label="Фото"
              color="white"
              accept="image/*"
              @update:model-value="updateFile()"
            />
        </div>
        <div class="col-1 q-my-md no-wrap">
          <q-input color="white" filled v-model="name" label="Имя"/>
        </div>
        <div class="col-1 q-my-md no-wrap">
          <q-input color="white" v-model="birthday" filled type="date" label="Дата рождения" />
        </div>

        <div class="col-1 q-my-md column justify-center">
          <div class="col row justify-center">
            <q-btn class="col" color="white" outline stack rounded icon="done" label="Сохранить" @click="saveOnClick()"></q-btn>
            <div class="col-1"></div>
            <q-btn class="col" color="white" outline stack rounded icon="cancel" label="Отменить" @click="cancelOnClick()"></q-btn>
          </div>
        </div>
      </div>
    </q-card-section>
  </q-card>
</template>

<style>
  .bg-color {
    background-color:rgba(32, 32, 63, 0.5);
  }
</style>

<script>
import {api} from "boot/axios";
import {useQuasar} from "quasar";
import {ref} from "vue";
import moment from "moment";
import {useRouter} from "vue-router/dist/vue-router";

export default {
  name: "HumanCardAddComponent",
  components: {},

  setup(props, context) {
    const q = useQuasar();
    const image = ref(null);
    const imageUrl = ref('');
    const birthday = ref(moment().format('YYYY/MM/DD'));
    const name = ref('');
    const router = useRouter();

    function updateFile() {
      imageUrl.value = URL.createObjectURL(image.value);
    }

    return { q, router, image, imageUrl, updateFile, birthday, name}
  },

  methods: {
    toBase64(file) {
      let reader = new FileReader();
      reader.readAsDataURL(file);

      return new Promise((resolve, reject) => {
        reader.onerror = () => {
          reader.abort();
          reject("Не удалось преобразовать изображение")
        };

        reader.onload = function () {
          resolve(reader.result);
        };
      })
    },

    async saveOnClick() {
      let photo = '';
      if (this.imageUrl !== ''){
        photo = await this.toBase64(this.image)
      }

      this.createHuman(this.name, moment(this.birthday,'YYYY/MM/DD').format('DD.MM.YYYY'), photo);
    },

    cancelOnClick(){
      this.router.push({name: 'AllBirthdaysIndex'});
    },

    createHuman(name, birthday, photo){
      api.post('/api/humans/createHuman', {Name: name, Birthday: birthday, Photo: photo}, {
        headers: {
          'Content-Type': 'application/json'
        }
      }).then((response) => {
          this.q.notify({
            color: 'positive',
            position: 'top',
            message: this.name + ' добавлен',
            icon: 'done'
          });
          this.router.push({name: 'AllBirthdaysIndex'});
        })
        .catch((e) => {
          console.log(e);
          this.q.notify({
            color: 'negative',
            position: 'top',
            message: 'Не удалось добавить человека',
            icon: 'report_problem'
          })
        });
    }
  }
}
</script>
