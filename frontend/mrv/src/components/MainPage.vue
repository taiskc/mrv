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
      <div v-for="approvedLead in approvedLeads" v-bind:key="approvedLead.id">
        <new-lead-card :lead="approvedLead" />
      </div>
    </div>
  </div>
</template>

<script>
import NewLeadCard from "./NewLeadCard.vue";

export default {
  name: "main-page",
  components: {
    NewLeadCard,
  },
  data() {
    return {
      newLeads: [],
      approvedLeads: [],
      loadingNewLeads: true,
      loadingApprovedLeads: true,
      tabSelected: "Invited",
    };
  },
  created() {
    this.getAllLeads();
  },
  methods: {
    getAllLeads() {
      this.getNewLeads();
      this.getApprovedLeads();
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
    async getApprovedLeads() {
      fetch("https://localhost:7079/api/lead/approved", { method: "GET" })
        .then(async (response) => {
          this.approvedLeads = await response.json();
        })
        .catch((error) => {
          this.errorMessage = error;
          console.error("There was an error!", error);
        });
      this.loadingApprovedLeads = false;
    },
    setActive(tab) {
      this.tabSelected = tab;
    },
  },
};
</script>