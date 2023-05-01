<script setup>





import { ref,reactive,  onMounted, computed, watch } from 'vue';
import { useRouter } from 'vue-router';
const router = useRouter()
const b_num = ref('0')
const building = reactive({})

onMounted(()=>{

	const options = {
		method: 'GET',
	};
	const {
		host, hostname, href, origin, pathname, port, protocol, search
	} = window.location
	console.log(href.split('/')[4])
	fetch(`http://localhost:5156/api/energy/${href.split('/')[4]}`, options)
	.then(response => response.json())
	.then(response => {console.log(response); building.value = response} )
	.catch(err => console.error(err));
	
})
const save = () => {
	const options = {
  method: 'PUT',
  headers: {
    'Content-Type': 'application/json'
  },
  body: JSON.stringify(building.value)
};

fetch('http://localhost:5156/api/energy', options)
  .then(response => response.json())
  .then(response => console.log(response))
  .catch(err => console.error(err));
  router.push('/buildings');
}


</script>


<template>
	
	<div class="buildingsPage">
		<h1>Building {{ $route.params.id }}</h1>
		<button >Add</button>
	<div class="buildingForm">
		<div v-if="building" v-for="(value, key, index) in building.value" :key="index">
			<div class="form-group">
				<label :for="`${key}${index}`">{{ key.toUpperCase() }}:</label>
				<input type="text" class="form-control w-50" :id="`${key}${index}`" :placeholder="value" >
			</div>
		</div>
	</div>
	
	<div class="options">
		<button type="button" @click="save()" class="btn btn-primary">Save</button>
		<button type="button" class="btn btn-secondary">Cancel</button>
	</div>

	</div>
</template>


<style scoped>
.buildingForm {
	margin-left: 1rem;
}
.building_list_item {
	display: flex;
	flex-direction: row;
	align-items: center;
	justify-content: space-between;
	width: 100%;
	margin-bottom: 5px;
}

.field {
	width: 18%;
}

.buildingsPage {
	width: 100%;
}

.odd {
	background-color: aqua;
}
</style>
