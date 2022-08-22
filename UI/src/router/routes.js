const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      {
        name: 'ComingBirthdaysIndex',
        path: '',
        component: () => import('pages/ComingBirthdaysPage'),
        children: [
          {
            name: 'ComingBirthdaysView',
            path: 'view/:id',
            component: () => import('components/HumanCardComponent'),
            props: true,
          },
        ],
      },
      {
        name: 'AllBirthdaysIndex',
        path: 'all_birthdays',
        component: () => import ('pages/AllBirthdaysPage'),
        children: [
          {
            name: 'AllBirthdaysView',
            path: 'view/:id',
            component: () => import('components/HumanCardComponent'),
            props: true,
          },
          {
            name: 'AllBirthdaysEdit',
            path: 'edit/:id',
            component: () => import('components/HumanCardEditComponent'),
            props: true,
          },
          {
            name: 'AllBirthdaysAdd',
            path: 'add',
            component: () => import('components/HumanCardAddComponent')
          }
        ]
      }
    ]
  },

  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
