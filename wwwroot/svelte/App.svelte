<svelte:options tag="svelte-app" />
<script>
    export let name;
    export let id;
	
    const fetchImage = (async () => {
		const response = await fetch('/api/User')
        console.log("Merhaba Dünya");
        return await response.json()
	})()
    console.log(fetchImage)
</script>

{#await fetchImage}
	<p>...waiting</p>
{:then data}
    <span>{data.name}</span>
{:catch error}
	<p>An error occurred!</p>
{/await}

<main>
    <h1 id="{id}">Hello {name}!</h1>
</main>

<style>
    h1 {
        font-size: 5em;
    }
</style>
