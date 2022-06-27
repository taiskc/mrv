<template>
  <div id="app">
    <img src="./assets/logo.png">
    <h1>{{ msg }}</h1>
    <b-card>Essential Links</b-card>
    <ul>
      <li><a href="https://vuejs.org" target="_blank">Core Docs</a></li>
      <li><a href="https://forum.vuejs.org" target="_blank">Forum</a></li>
      <li><a href="https://gitter.im/vuejs/vue" target="_blank">Gitter Chat</a></li>
      <li><a href="https://twitter.com/vuejs" target="_blank">Twitter</a></li>
    </ul>
    <h2>Ecosystem</h2>
    <ul>
      <li><a href="http://router.vuejs.org/" target="_blank">vue-router</a></li>
      <li><a href="http://vuex.vuejs.org/" target="_blank">vuex</a></li>
      <li><a href="http://vue-loader.vuejs.org/" target="_blank">vue-loader</a></li>
      <li><a href="https://github.com/vuejs/awesome-vue" target="_blank">awesome-vue</a></li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'app',
  data () {
    return {
      newLeads: [],
      approvedLeads: []
    }
  },
  created() {
    this.getAllLeads()
  },
  getAllLeads() {
    this.getNewLeads();
    this.getAcceptedLeads();
  },
  async getNewLeads() {
        fetch("https://localhost:7079/lead/new", {method: 'GET'})
    .then(async response => {
      const data = await response.json();
      if (!response.ok) {
        this.newLeads = response;
        debugger;
        return Promise.reject(error);
      }
    })
    .catch(error => {
      this.errorMessage = error;
      console.error("There was an error!", error);
    });
  }
}
</script>