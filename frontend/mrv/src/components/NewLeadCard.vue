<template>
  <div>
    <b-card class="my-2">
      <div class="d-flex flex-row align-items-center">
        <div class="avatar">{{ lead.firstName.charAt(0) }}</div>
        <div class="d-flex flex-column">
          <div>{{ lead.firstName }}</div>
          <div>{{ getFormattedDate(lead.createdAt) }}</div>
        </div>
      </div>
      <hr class="w-100"/>
      <div class="d-flex flex-row align-items-center">
        <div class="mr-4 d-flex align-items-center"><img class="icon mr-1" src="../assets/icons/map-pin.svg"/>{{ lead.suburb }}</div>
        <div class="mr-4 d-flex align-items-center"><img class="icon mr-1" src="../assets/icons/briefcase.svg"/> {{ lead.category }}</div>
        <div>JOB ID: {{ lead.id }}</div>
      </div>
      <hr class="w-100" />
      {{ lead.description }}
      <hr class="w-100" />
      <div class="d-flex flex-row align-items-center">
        <div v-if="loadingEvaluation" class="spinner-border mr-2" role="status">
            <span class="sr-only">Loading...</span>
        </div>
        <b-button class="mr-2" variant="warning" @click="evaluateLead(true)" :disabled="loadingEvaluation">Accept</b-button>
        <b-button class="mr-2" @click="evaluateLead(false)" :disabled="loadingEvaluation">Decline</b-button>
        ${{ lead.price.toFixed(2) + " Lead Invitation" }}
      </div>
    </b-card>
    <b-modal
      ref="generalModal"
      centered
      hide-header
      ok-only
      ok-title="Ok"
      @hide="updateLeads"
      class="theme-modal"
    >
      {{ modalMessage }}
    </b-modal>
  </div>
</template>

<script>
import moment from "moment";
export default {
  name: "new-lead-card",
  props: ["lead"],
  data() {
    return {
        loadingEvaluation: false,
        leadComplete: null,
        modalMessage: '',
        evaluation: null,
    };
  },
  methods: {
    getFormattedDate(date) {
      const formattedDate = moment(date).format("ll");
      const formattedTime = moment(date).format("LT");
      return formattedDate + " @ " + formattedTime;
    },
    updateLeads() {
        this.$emit('updateLeads', this.evaluation, this.leadComplete);
    },
    evaluateLead(evaluation) {
        this.evaluation = evaluation;
        this.loadingEvaluation = true;
        const body = JSON.stringify({ "accepted": evaluation });
        fetch("https://localhost:7079/api/lead/evaluate/" + this.lead.id + '/',
            { method: "PUT",
            headers: {
            "Content-Type": "application/json",
            },
            body: body })
            .then(async (response) => {
                const data = await response.json();
                if (evaluation) {
                    this.leadComplete = data;
                } else {
                    this.leadComplete = this.lead;
                }
                const middleOfMessage = evaluation ? "accepted" : "declined"
                this.modalMessage = "Lead " + middleOfMessage + " successfully!";
                this.$refs['generalModal'].show();
            })
            .catch((error) => {
                const middleOfMessage = evaluation ? "accepted" : "declined"
                this.modalMessage = "There was an error and the lead could not be " + middleOfMessage + "! Please, try again.";
                this.$refs['generalModal'].show();
                this.errorMessage = error;
                console.error("There was an error!", error);
            });
        this.loadingEvaluation = false;
    }
  },
};
</script>