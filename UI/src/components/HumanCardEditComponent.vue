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
            :input-style="{color : '#dedefc' }"
            @update:model-value="updateFile()"
          />
        </div>
        <div class="col-1 q-my-md no-wrap">
          <q-input color="white" :input-style="{color : '#dedefc' }" filled v-model="name" label="Имя"/>
        </div>
        <div class="col-1 q-my-md no-wrap">
          <q-input color="white" :input-style="{color : '#dedefc' }" v-model="birthday" filled type="date" label="Дата рождения" />
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

    const image = ref(null);
    const imageUrl = ref('');
    const birthday = ref();
    const name = ref('');
    const router = useRouter();

    function b64toBlob(b64Data, contentType='image/png', sliceSize=512) {
      const byteCharacters = atob(b64Data);
      const byteArrays = [];

      for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        const slice = byteCharacters.slice(offset, offset + sliceSize);

        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
          byteNumbers[i] = slice.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
      }

      const blob = new Blob(byteArrays, {type: contentType});
      return blob;
    };

    function loadData(id){
      if (typeof id === 'undefined'){
        return;
      }

      api.get('/api/humans/getHumanById', { params:{ Id: parseInt(id) } })
        .then((response) => {
          let human = response.data;
          name.value = human.name;
          birthday.value = moment(human.birthday, 'DD.MM.YYYY').format('YYYY.MM.DD');
          image.value = b64toBlob(human.photo.substr(human.photo.indexOf(',') + 1));
          updateFile();
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

    function updateFile() {
      imageUrl.value = URL.createObjectURL(image.value);
    }

    loadData(props.id);


    return { q, router, image, imageUrl, updateFile, birthday, name, loadData}
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

      this.updateHuman(this.id, this.name, moment(this.birthday,'YYYY/MM/DD').format('DD.MM.YYYY'), photo);
    },

    cancelOnClick(){
      this.router.push({name: 'AllBirthdaysIndex'});
    },

    updateHuman(id, name, birthday, photo){
      api.post('/api/humans/updateHuman', {Id: id, Name: name, Birthday: birthday, Photo: photo}, {
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
