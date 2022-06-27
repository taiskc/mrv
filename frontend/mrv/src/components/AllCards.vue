<template>
  <div>
    <b-card v-if="loadingLeads">
        <div class="w-100 d-flex alig-items-center justify-content-center">
          <div class="spinner-border" role="status">
            <span class="sr-only">Loading...</span>
          </div>
        </div>
      </b-card>
      <div v-else>
        <div v-if="leads.length > 0">
          <div v-for="lead in leads" v-bind:key="lead.id">
            <new-lead-card v-if="type === 'Invited'" :lead="lead" />
            <accepted-lead-card v-else :lead="lead" />
          </div>
        </div>
        <div v-else>
          <b-card class="my-2" v-if="errorLoadingLeads">
            There was an error while loading the leads! Please, try again.
          </b-card>
          <b-card class="my-2" v-if="!errorLoadingLeads">No leads.</b-card>
        </div>
      </div>
  </div>
</template>

<script>
import NewLeadCard from "./NewLeadCard.vue";
import AcceptedLeadCard from "./AcceptedLeadCard.vue";
export default {
  name: "all-cards",
  components: { NewLeadCard, AcceptedLeadCard },
  props: ["type", "leads", "errorLoadingLeads", "loadingLeads", "updateLeads"],
  data() {
    return {
    };
  },
};
</script>