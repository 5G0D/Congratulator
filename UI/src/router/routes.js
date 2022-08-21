const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/ComingBirthdaysPage') },
      //{ path: 'new', component: () => import('pages/New.vue') },
      //{ path: 'note/:id', component: () => import('pages/NotePage.vue') },
      //{ path: 'coming_birthdays', component: () => import ('pages/ComingBirthdaysPage') },
      { path: 'all_birthdays', component: () => import ('pages/AllBirthdaysPage') }
    ]
  },

  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
