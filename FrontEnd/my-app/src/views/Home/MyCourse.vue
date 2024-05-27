<template>
  <div>
    <div style="min-height: 72px">
      <HeaderItem></HeaderItem>
    </div>
    <div class="menu-course">
      <div class="container">
        <div class="content-header-item">
          <h2>Khóa học của bạn</h2>
        </div>
        <div>
          <v-tabs v-model="tab" align-tabs="left">
            <v-tab :value="1">Tất cả khóa học</v-tab>
            <v-tab :value="2">Mong muốn</v-tab>
          </v-tabs>
        </div>
      </div>
    </div>
    <div class="container">
      <v-window v-model="tab">
        <v-window-item :value="1">
          <div class="mt-10 mb-13" elevation="8">
            <v-slide-group
              v-model="model"
              class="pa-4"
              selected-class="bg-success"
              show-arrows
            >
              <v-slide-group-item>
                <v-hover
                  v-slot="{ isHovering, props }"
                  v-for="c in listCourseApi"
                  :key="c.id"
                >
                  <router-link :to="`/video-lessons/${c.id}`" style="text-decoration:none;">
                    <v-card
                      :loading="loading"
                      :class="{ 'on-hover': isHovering }"
                      :elevation="isHovering ? 12 : 2"
                      class="ma-4 image-content"
                      v-bind="props"
                      width="260"
                    >
                      <template v-slot:loader="{ isActive }">
                        <v-progress-linear
                          :active="isActive"
                          color="deep-purple"
                          height="4"
                          indeterminate
                        ></v-progress-linear>
                      </template>

                      <v-img :src="c.image" height="160" cover>
                        <div class="hover-image text-center">
                          <v-btn
                            icon="mdi-play"
                            color="white"
                            size="x-large"
                            variant="flat"
                            class="icon-image"
                          ></v-btn>
                        </div>
                      </v-img>

                      <v-card-item>
                        <v-card-title>{{ c.title }}</v-card-title>

                        <v-card-subtitle>
                          <span class="me-1">{{ c.creatorName }}</span>
                          <v-progress-linear
                            v-model="c.skill"
                            striped
                            color="blue"
                            height="10"
                            class="mt-3"
                          >
                            <strong>{{ c.skill }}%</strong>
                          </v-progress-linear>
                          <v-icon
                            color="error"
                            icon="mdi-fire-circle"
                            size="small"
                          ></v-icon>
                        </v-card-subtitle>
                      </v-card-item>

                      <v-card-text class="mb-5">
                        <v-row align="center" class="mx-0">
                          <v-dialog max-width="500">
                            <template
                              v-slot:activator="{ props: activatorProps }"
                            >
                              <v-btn variant="text" v-bind="activatorProps">
                                <v-rating
                                  :model-value="4.5"
                                  color="amber"
                                  density="compact"
                                  size="small"
                                  half-increments
                                  readonly
                                ></v-rating
                              ></v-btn>
                            </template>

                            <template v-slot:default="{ isActive }">
                              <v-card title="Đánh giá cá nhân">
                                <v-card-text>
                                  <v-rating
                                    v-model="rating"
                                    active-color="orange"
                                    color="orange-lighten-1"
                                    half-increments
                                    hover
                                  ></v-rating>
                                </v-card-text>

                                <v-card-actions>
                                  <v-spacer></v-spacer>

                                  <v-btn
                                    text="Gửi"
                                    @click="isActive.value = false"
                                  ></v-btn>
                                </v-card-actions>
                              </v-card>
                            </template>
                          </v-dialog>

                          <div class="text-grey ms-4">4.5 (413)</div>
                        </v-row>
                      </v-card-text>
                    </v-card>
                  </router-link>
                </v-hover>
              </v-slide-group-item>
            </v-slide-group>
          </div>
        </v-window-item>
        <v-window-item :value="2">
          <div class="desire text-center mt-16">
            <router-link to="/">
              <v-btn
                :disabled="loading"
                :loading="loading"
                class="text-none mb-4"
                color="black"
                size="x-large"
                variant="flat"
                @click="loading = !loading"
              >
                Xem ngay các khóa học
              </v-btn>
            </router-link>
          </div>
        </v-window-item>
      </v-window>
    </div>
    <div class="teaching">
      <v-row>
        <v-col>
          <div class="content-teaching mt-1 ml-14">
            <h3>Giảng dạy online cho cả thế giới</h3>
            <p>
              Tạo một khóa học video online, tiếp cận học viên trên toàn cầu và
              kiếm tiền
            </p>
          </div>
        </v-col>
        <v-col>
          <div class="button-teaching text-right">
            <router-link to="/course-product">
              <v-btn
                :disabled="loading"
                :loading="loading"
                class="text-none mb-4 mt-3 mr-14"
                color="white"
                size="x-large"
                variant="outlined"
                @click="loading = !loading"
              >
                Giảng dạy trên MyBugs
              </v-btn>
            </router-link>
          </div>
        </v-col>
      </v-row>
    </div>
    <div>
      <FooterItem class="footer"></FooterItem>
    </div>
  </div>
</template>

<script>
import HeaderItem from "../Header/HeaderItem.vue";
import FooterItem from "../Header/FooterItem.vue";
import { useRouter } from "vue-router";
import {courseApi} from "../../apis/Course/courseApi"
export default {
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      loading: false,
      selection: 1,
      tab: null,
      model: null,
      rating: 1,
      courseApi: courseApi(),
      listCourseApi: [],
      listCourse: []
    };
  },
  async mounted() {
    try{
      const res = await this.courseApi.getAllCourses()
      this.listCourseApi = res.dataResponseCourse
      console.log(this.listCourseApi);
    }catch(e){
      console.error('Error fetching' + e.message);
    }
  },
};

</script>

<style scope>
.icon-image {
  display: block;
  color: rgb(0, 0, 0);
}
.hover-image {
  display: none;

  padding-top: 50px;
  padding-left: 100px;
  /* z-index: 2; */
}
.image-content:hover .hover-image {
  background-color: rgb(0, 0, 0);

  height: 100%;
  opacity: 0.6;
  /* z-index: 2; */
  display: block;
}
/* .show-btns {
  color: rgba(255, 255, 255, 1) !important;
} */
/*  */
.footer {
  border-radius: 0%;
}
.content-header-item {
  font-family: initial;
  padding: 40px 0px 20px 0px;
}
.content-header-item h2 {
  font-size: 40px;
}
.teaching {
  background-color: rgb(24, 21, 21);
  border-bottom: 1px solid rgb(93, 93, 93);
  /* height: 100px; */
}
.content-teaching {
  color: white;
}
.menu-course {
  background-color: rgb(24, 21, 21);
  color: white;
}
.border-content-course {
  box-shadow: 1px 1px 10px 1px rgb(0, 0, 0);
}
.desire {
  height: 404px;
}
</style>
