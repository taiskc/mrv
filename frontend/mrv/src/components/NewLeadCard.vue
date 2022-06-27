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
        <b-button class="mr-2" variant="warning">Accept</b-button>
        <b-button class="mr-2">Decline</b-button>
        {{ lead.price }}
      </div>
    </b-card>
  </div>
</template>

<script>
import moment from "moment";
export default {
  name: "new-lead-card",
  props: ["lead"],
  data() {
    return {};
  },
  methods: {
    getFormattedDate(date) {
      const formattedDate = moment(date).format("ll");
      const formattedTime = moment(date).format("LT");
      return formattedDate + " @ " + formattedTime;
    },
  },
};
</script>