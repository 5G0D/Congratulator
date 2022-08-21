<template>
  <q-card
    flat
    class="rounded bg-color"
  >
    <q-card-section style="height: 30vh">
      <div class="column fit">
        <div class="col-12 col-md-6"><q-img height="100%" fit="contain" :src="photo"></q-img></div>
        <div class="col-12 col-md-4" style="word-break: break-word; overflow: hidden">{{ name }}</div>
      </div>
    </q-card-section>
  </q-card>
</template>

<script>
export default {
  name: "HumanElementCard",
  props: {
    name: String,
    birthday: String,
    photo: String,
  }
}
</script>

<style scoped>
  .bg-color {
    background-color:rgba(32, 32, 63, 0.2);
  }
</style>
