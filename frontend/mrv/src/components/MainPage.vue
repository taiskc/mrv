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
      <all-cards type="Invited" @updateLeads="updateLeads" :loadingLeads="loadingNewLeads" :errorLoadingLeads="errorLoadingNewLeads" :leads="newLeads"/>
    </div>
    <div v-else>
      <all-cards type="Accepted" :loadingLeads="loadingAcceptedLeads" :errorLoadingLeads="errorLoadingAcceptedLeads" :leads="acceptedLeads"/>
    </div>
  </div>
</template>

<script>
import AllCards from "./AllCards.vue";

export default {
  name: "main-page",
  components: {
    AllCards,
  },
  data() {
    return {
      newLeads: [],
      acceptedLeads: [],
      loadingNewLeads: true,
      loadingAcceptedLeads: true,
      errorLoadingNewLeads: false,
      errorLoadingAcceptedLeads: false,
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
          this.loadingNewLeads = false;
        })
        .catch((error) => {
          this.errorMessage = error;
          this.errorLoadingNewLeads = true;
          console.error("There was an error!", error);
          this.loadingNewLeads = false;
        });
    },
    async getAcceptedLeads() {
      fetch("https://localhost:7079/api/lead/accepted", { method: "GET" })
        .then(async (response) => {
          this.acceptedLeads = await response.json();
          this.loadingAcceptedLeads = false;
        })
        .catch((error) => {
          this.errorMessage = error;
          this.errorLoadingAcceptedLeads = true;
          console.error("There was an error!", error);
          this.loadingAcceptedLeads = false;
        });
    },
    setActive(tab) {
      this.tabSelected = tab;
    },
    updateLeads(evaluation, lead) {
      if (evaluation) {
        this.changeLeadToAceepted(lead);
      } else {
        this.removeLead(lead);
      }
    },
    removeLead(lead) {
      this.newLeads = this.newLeads.filter((newLead) => newLead.id !== lead.id);
    },
    changeLeadToAceepted(lead) {
      this.removeLead(lead);
      this.acceptedLeads.push(lead);
      this.acceptedLeads = this.acceptedLeads.sort(function (a, b) {
        return new Date(a.createdAt) - new Date(b.createdAt);
      });
    },
  },
};
</script>