<template>
  <div>
    <b-card>
      <div class="d-flex flex-row justify-content-around">
        <div
          class="clickable"
          :class="{ active: tabSelected == 'Invited' }"
          @click="setActive('Invited')"
        >
          Invited
        </div>
        <div
          class="clickable"
          :class="{ active: tabSelected == 'Accepted' }"
          @click="setActive('Accepted')"
        >
          Accepted
        </div>
      </div>
    </b-card>
    <div v-if="tabSelected == 'Invited'">
      <div v-for="newLead in newLeads" v-bind:key="newLead.id">
        <new-lead-card :lead="newLead" />
      </div>
    </div>
    <div v-else>
      <div v-for="acceptedLead in acceptedLeads" v-bind:key="acceptedLead.id">
        <accepted-lead-card :lead="acceptedLead" />
      </div>
    </div>
  </div>
</template>

<script>
import NewLeadCard from "./NewLeadCard.vue";
import AcceptedLeadCard from "./AcceptedLeadCard.vue";

export default {
  name: "main-page",
  components: {
    NewLeadCard,
    AcceptedLeadCard,
  },
  data() {
    return {
      newLeads: [],
      acceptedLeads: [],
      loadingNewLeads: true,
      loadingAcceptedLeads: true,
      tabSelected: "Invited",
    };
  },
  created() {
    this.getAllLeads();
  },
  methods: {
    getAllLeads() {
      this.getNewLeads();
      this.getAcceptedLeads();
    },
    async getNewLeads() {
      fetch("https://localhost:7079/api/lead/new", { method: "GET" })
        .then(async (response) => {
          this.newLeads = await response.json();
        })
        .catch((error) => {
          this.errorMessage = error;
          console.error("There was an error!", error);
        });
      this.loadingNewLeads = false;
    },
    async getAcceptedLeads() {
      fetch("https://localhost:7079/api/lead/accepted", { method: "GET" })
        .then(async (response) => {
          this.acceptedLeads = await response.json();
        })
        .catch((error) => {
          this.errorMessage = error;
          console.error("There was an error!", error);
        });
      this.loadingAcceptedLeads = false;
    },
    setActive(tab) {
      this.tabSelected = tab;
    },
  },
};
</script>