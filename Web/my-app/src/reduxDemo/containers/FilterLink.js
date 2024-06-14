import Link from '../components/Link'
import { connect } from 'react-redux'
import { setVisibilityFilter } from '../actions'

// state传递给展示组件的props
// ownProps是容器组件的props
const mapStateToProps = (state, ownProps) => {
  return {
    active: ownProps.filter === state.visibilityFilter
  }
}

// dispatch方法传递给展示组件的props
const mapDispatchToProps = (dispatch, ownProps) => {
  return {
    onClick: () => {
      dispatch(setVisibilityFilter(ownProps.filter))
    }
  }
}

// 使用connect创建容器组件
const FilterLink = connect(
  mapStateToProps,
  mapDispatchToProps
)(Link)

export default FilterLink