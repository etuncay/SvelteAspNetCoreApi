<svelte:options tag="svelte-user-table" />
<script>
	
    const fetchData = (async () => {
		const response = await fetch('/api/User')
        console.log("Merhaba Dünya");
        return await response.json()
	})()
</script>


<main>    
    {#await fetchData}
        <p>...waiting</p>
        {:then data}
            <table>
                <tbody>
                    <tr>
                        <th>Ad</th>
                        <th>Soyad</th>
                    </tr>
                </tbody>
                <body>
                    {#each data as user}
                    <tr>
                        <td>{user.name}</td>
                        <td>{user.surname}</td>
                    </tr> 
                    {/each}
                </body>
            </table>
        {:catch error}
        <p>An error occurred!</p>
    {/await}
</main>

