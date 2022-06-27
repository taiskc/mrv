<template>
  <div>
    {{ lead.firstName }}
    {{ lead.createdAt }}
    {{ lead.suburb }}
    {{ lead.category }}
    {{ lead.id }}
    {{ lead.description }}
    {{ lead.price }}
  </div>
</template>

<script>
export default {
    name: 'new-lead-card',
    props: ['lead'],
    data () {
        return {
        }
    },
}
</script>