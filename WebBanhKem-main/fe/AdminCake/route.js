import Vue from 'vue'
import Router from 'vue-router'
import { normalizeURL, decode } from 'ufo'
import { interopDefault } from './utils'
import scrollBehavior from './router.scrollBehavior.js'

const _b5b3425a = () => interopDefault(import('..\\pages\\admin\\index.vue' /* webpackChunkName: "pages/admin/index" */))
const _31b75520 = () => interopDefault(import('..\\pages\\contact.vue' /* webpackChunkName: "pages/contact" */))
const _17b27509 = () => interopDefault(import('..\\pages\\dathang.vue' /* webpackChunkName: "pages/dathang" */))
const _42edcde9 = () => interopDefault(import('..\\pages\\login.vue' /* webpackChunkName: "pages/login" */))
const _334ae63e = () => interopDefault(import('..\\pages\\admin\\contact.vue' /* webpackChunkName: "pages/admin/contact" */))
const _bd7fe146 = () => interopDefault(import('..\\pages\\user\\logined.vue' /* webpackChunkName: "pages/user/logined" */))
const _84a98c84 = () => interopDefault(import('..\\pages\\admin\\products\\add.vue' /* webpackChunkName: "pages/admin/products/add" */))
const _79462ad2 = () => interopDefault(import('..\\pages\\index.vue' /* webpackChunkName: "pages/index" */))

const emptyFn = () => {}

Vue.use(Router)

export const routerOptions = {
  mode: 'history',
  base: '/',
  linkActiveClass: 'nuxt-link-active',
  linkExactActiveClass: 'nuxt-link-exact-active',
  scrollBehavior,

  routes: [{
    path: "/admin",
    component: _b5b3425a,
    name: "admin"
  }, {
    path: "/contact",
    component: _31b75520,
    name: "contact"
  }, {
    path: "/dathang/:id",
    component: _17b27509,
    name: "dathang"
  }, {
    path: "/login",
    component: _42edcde9,
    name: "login"
  }, {
    path: "/admin/contact",
    component: _334ae63e,
    name: "admin-contact"
  }, {
    path: "/user/logined",
    component: _bd7fe146,
    name: "user-logined"
  }, {
    path: "/admin/products/add",
    component: _84a98c84,
    name: "admin-products-add"
  }, {
    path: "/",
    component: _79462ad2,
    name: "index"
  }],

  fallback: false
}

export function createRouter (ssrContext, config) {
  const base = (config._app && config._app.basePath) || routerOptions.base
  const router = new Router({ ...routerOptions, base  })

  // TODO: remove in Nuxt 3
  const originalPush = router.push
  router.push = function push (location, onComplete = emptyFn, onAbort) {
    return originalPush.call(this, location, onComplete, onAbort)
  }

  const resolve = router.resolve.bind(router)
  router.resolve = (to, current, append) => {
    if (typeof to === 'string') {
      to = normalizeURL(to)
    }
    return resolve(to, current, append)
  }

  return router
}
