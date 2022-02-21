<svelte:options tag="svelte-app" />
<script>
    export let message;
</script>


<main>
    <h1 >{message}</h1>
</main>

<style>
    h1 {
        font-size: 5em;
    }
</style>
