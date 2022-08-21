<template>
  <div class="bg-image">
    <q-layout view="hHh lpR fFf">

      <q-page-container>
        <router-view />
      </q-page-container>

      <q-footer class="bg-transparent">
        <div class="row no-wrap items-center justify-center q-mb-sm">
          <q-btn class="q-mx-sm additional_butt text-capitalize" size=md unelevated rounded color="primary" label="Ближайшие ДР" to="/"></q-btn>
          <q-btn size=lg unelevated round color="primary" icon="add"></q-btn>
          <q-btn class="q-mx-sm additional_butt text-capitalize" unelevated size=md rounded color="primary" label="Все ДР" to="all_birthdays"></q-btn>
        </div>
      </q-footer>
    </q-layout>
  </div>
</template>

<style>
  .bg-image {
    background-image: url(../assets/background.jpg);
    background-repeat: no-repeat;
    background-size: cover;
    background-position: center center;
  }

  .additional_butt{
    line-height: 2.5;
    width: 150px
  }

</style>
