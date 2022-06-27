<template>
  <div>
    <b-card class="my-2">
      <div class="d-flex flex-row align-items-center">
        <div class="avatar">{{ lead.firstName.charAt(0) }}</div>
        <div class="d-flex flex-column">
          <div class="font-weight-bold">{{ lead.firstName + " " + lead.lastName }}</div>
          <div>{{ getFormattedDate(lead.createdAt) }}</div>
        </div>
      </div>
      <hr class="w-100"/>
      <div class="d-flex flex-row align-items-center">
        <div class="mr-4 d-flex align-items-center"><img class="icon mr-1" src="../assets/icons/map-pin.svg"/>{{ lead.suburb }}</div>
        <div class="mr-4 d-flex align-items-center"><img class="icon mr-1" src="../assets/icons/briefcase.svg"/> {{ lead.category }}</div>
        <div class="mr-4">JOB ID: {{ lead.id }}</div>
        <div class="font-weight-bold mr-1">${{ lead.price.toFixed(2)}}</div><span>Lead Invitation</span>
      </div>
      <hr class="w-100"/>
      <div class="d-flex flex-row align-items-center">
        <div class="mr-4 d-flex align-items-center text-warning"><img class="icon mr-1" src="../assets/icons/phone.svg"/>{{ lead.phone }}</div>
        <div class="mr-4 d-flex align-items-center text-warning"><img class="icon mr-1" src="../assets/icons/mail.svg"/> {{ lead.email }}</div>
      </div>
      <hr class="w-100" />
      {{ lead.description }}
    </b-card>
    <b-modal
      ref="generalModal"
      centered
      hide-header
      ok-only
      ok-title="Ok"
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
    };
  },
  methods: {
    getFormattedDate(date) {
      const formattedDate = moment(date).format("ll");
      const formattedTime = moment(date).format("LT");
      return formattedDate + " @ " + formattedTime;
    },
    evaluateLead(evaluation) {
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
                    const middleOfMessage = evaluation ? "accepted" : "declined"
                    this.modalMessage = "Lead " + middleOfMessage + " successfully!";
                    this.$refs['generalModal'].show();
                }
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